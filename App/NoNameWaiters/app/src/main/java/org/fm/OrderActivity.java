package org.fm;

import android.app.ActionBar;
import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.DialogFragment;

import org.fm.data.RepoFactory;
import org.fm.data.Repository;
import org.fm.model.Cat;
import org.fm.model.Drink;

import java.util.ArrayList;
import java.util.Dictionary;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;

public class  OrderActivity extends AppCompatActivity {
    public static String USERNAME = "USERNAME";
    private String waiterName;
    private int tableNumBeg = 0;
    private Repository repo;
    private List<String> listCats;
    private Dictionary<String, Cat> dictOfCategories;
    private List<String> listCart;
    ArrayAdapter<String> aCart;
    ArrayAdapter<String> aProducts;
    CharSequence[] drinksForCat;
    List<Drink> drinksForCategory;
    List<Drink> cart;


    @BindView(R.id.btnOrder)
    Button btnOrder;
    @BindView(R.id.tvTableNumber)
    TextView tvTableNumber;
    @BindView(R.id.lvCart)
    ListView lvCart;
    @BindView(R.id.lvProducts)
    ListView lvProducts;
    @BindView(R.id.btnsMostOrdered)
    LinearLayout btnsMostOrd;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        resolveIntent();
        ButterKnife.bind(this);
        setData();
        initWidgets();
    }

    private void setData() {
        repo = RepoFactory.getRepo();
        getCategories();
        getTopThree();
        setCart();
    }

    private void getCategories() {
        List<Cat> cats = repo.getCategories();
        dictOfCategories = new Hashtable<>();
        listCats = new ArrayList<>();
        for (Cat cat: cats){
            dictOfCategories.put(cat.toString(), cat);
            listCats.add(cat.toString());
        }
        aProducts = new ArrayAdapter<String>(this, R.layout.categories_lv , listCats);
        lvProducts.setOnClickListener(v -> {
            TextView tv = (TextView) v;
            String s = tv.getText().toString();
            openChooserForDrink(s);
        });
        lvProducts.setAdapter(aProducts);
    }

    private void getTopThree() {
        List<Drink> topThreeDrinks = repo.getTopThreeDrinks();
        LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WRAP_CONTENT, LinearLayout.LayoutParams.MATCH_PARENT);
        for(Drink d : topThreeDrinks){
            Button b = new Button(this);
            b.setText(d.getName());
            b.setLayoutParams(lp);
            btnsMostOrd.addView(b);
        }
    }

    private void setCart() {
        listCart = new ArrayList<>();
        aCart = new ArrayAdapter<>(this, R.layout.categories_lv, listCart);
        lvCart.setAdapter(aCart);
    }


    //todo
    private void openChooserForDrink(String categoryName) {
        Cat cat = dictOfCategories.get(categoryName);
        drinksForCategory = repo.getDrinksForCategory(cat);
        drinksForCat = new CharSequence[drinksForCategory.size()];
        for (int i = 0; i < drinksForCategory.size(); i++) {
            drinksForCat[i] = drinksForCategory.get(i).toString();
        }
        DialogFragment dialog = new DrinkDialog();
        dialog.show(getSupportFragmentManager(), getString(R.string.drinks));
    }

    private void initWidgets() {
        tvTableNumber.setText(String.valueOf(tableNumBeg));
    }

    private void resolveIntent() {
        Intent i = getIntent();
        waiterName = i.getStringExtra(USERNAME);
    }

    @OnClick(R.id.btnPlus)
    void onClickPlus(){
        int num = Integer.parseInt(tvTableNumber.getText().toString());
        num++;
        tvTableNumber.setText(String.valueOf(num));
    }

    @OnClick(R.id.btnMinus)
    void onClickMinus(){
        int num = Integer.parseInt(tvTableNumber.getText().toString());
        num--;
        tvTableNumber.setText(String.valueOf(num));
    }

    //DrinkChooser
    public class DrinkDialog extends DialogFragment {
        @NonNull
        @Override
        public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setTitle(R.string.choose_drink)
                    .setItems(drinksForCat, new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            cart.add(drinksForCategory.get(which));
                            aCart.notifyDataSetChanged();
                        }
                    });
            return builder.create();
        }
    }
}
