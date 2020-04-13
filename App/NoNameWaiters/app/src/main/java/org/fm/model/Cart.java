package org.fm.model;

import java.util.ArrayList;
import java.util.List;

public class Cart extends ArrayList<CartItem> {
    public List<String> itemsNames;
    public int totalPrice;

    public Cart(){
        super();
        itemsNames = new ArrayList<>();
        totalPrice = 0;
    }

    @Override
    public boolean add(CartItem cartitem) {
        totalPrice += cartitem.getAmount() * cartitem.getDrink().getPrice();
        itemsNames.add(cartitem.getDrink().getName());
        return super.add(cartitem);
    }
}
