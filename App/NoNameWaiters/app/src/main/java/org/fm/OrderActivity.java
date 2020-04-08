package org.fm;

import android.content.Intent;
import android.os.Bundle;
import android.os.PersistableBundle;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import org.fm.data.RepoFactory;
import org.fm.data.Repository;
import org.fm.model.Cat;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;

public class  OrderActivity extends AppCompatActivity {
    public static String USERNAME = "USERNAME";
    private String waiterName;
    private int tableNumBeg = 0;
    private Repository repo;

    @BindView(R.id.btnOrder)
    Button btnOrder;
    @BindView(R.id.tvTableNumber)
    TextView tvTableNumber;
//    @BindView(R.id.lvCart)
//    ListView lvCart;
    @BindView(R.id.lvProducts)
    ListView lvProducts;

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
        List<Cat> cats = repo.getCategories();
        List<String> catsToShow = new ArrayList<>();
        for (Cat cat : cats) {
            catsToShow.add(cat.toString());
        }
        ArrayAdapter<String> aProducts = new ArrayAdapter<>(this, R.layout.categories_lv , catsToShow);
        lvProducts.setAdapter(aProducts);
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

}
