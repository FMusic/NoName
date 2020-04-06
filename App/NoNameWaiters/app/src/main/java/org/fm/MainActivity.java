package org.fm;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;

public class MainActivity extends AppCompatActivity {
    @BindView(R.id.etPassword)
    EditText etPassword;
    @BindView(R.id.etUsername)
    EditText etUsername;
    @BindView(R.id.btnSubmit)
    Button btnSubmit;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        logIn();
    }

    private void logIn() {
        setContentView(R.layout.login_layout);
        ButterKnife.bind(this);
    }

    @OnClick(R.id.btnSubmit)
    void onAction(){
        String pass = etPassword.getText().toString();
        String un = etUsername.getText().toString();
        if (un.equals("admin") && pass.equals("admin")){
            openOrderingScreen();
        }
    }

    private void openOrderingScreen() {
        Intent i = new Intent(this, OrderActivity.class);
        i.putExtra(OrderActivity.Username, etUsername.getText().toString());
        startActivity(i);
        //todo - forward to OrderActivity
    }
}
