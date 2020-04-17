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
        int j = -1;
        for (int i = 0; i < this.size(); i++) {
            if (get(i).getDrink().equals(cartitem.getDrink())){
                j = i;
                break;
            }
        }
        if (j == -1){
            super.add(cartitem);
        }
        else{
            get(j).setAmount(get(j).getAmount() + cartitem.getAmount());
        }
        resolveTotalPrice();
        resolveNames();
        return true;
    }

    public boolean changeQuantity(int cartInt, int newAmount){
        get(cartInt).setAmount(newAmount);
        resolveNames();
        resolveTotalPrice();
        return true;
    }

    private void resolveNames() {
        itemsNames.clear();
        for (int i = 0; i < this.size(); i++) {
            itemsNames.add(get(i).getAmount() + " " + get(i).getDrink().getName());
        }
    }

    private void resolveTotalPrice() {
        totalPrice =0;
        for (int i = 0; i < this.size(); i++) {
            totalPrice += get(i).getAmount() * get(i).getDrink().getPrice();
        }
    }
}
