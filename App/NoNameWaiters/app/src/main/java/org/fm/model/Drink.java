package org.fm.model;

import androidx.annotation.NonNull;

public class Drink {
    private int price;
    private String name;
    private Cat category;

    public Drink() {
    }

    public Drink(int price, String name, Cat category) {
        this.price = price;
        this.name = name;
        this.category = category;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Cat getCategory() {
        return category;
    }

    public void setCategory(Cat category) {
        this.category = category;
    }

    @NonNull
    @Override
    public String toString() {
        return name;
    }
}
