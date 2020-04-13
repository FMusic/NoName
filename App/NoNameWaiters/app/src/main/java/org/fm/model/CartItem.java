package org.fm.model;

public class CartItem {
    private Drink drink;
    private int amount;

    public CartItem(Drink drink, int amount) {
        this.drink = drink;
        this.amount = amount;
    }

    public CartItem(Drink drink) {
        this.drink = drink;
        amount = 1;
    }

    public Drink getDrink() {
        return drink;
    }

    public void setDrink(Drink drink) {
        this.drink = drink;
    }

    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }
}
