package org.fm.data;

import org.fm.model.Cat;
import org.fm.model.Drink;

import java.util.List;

public interface Repository {
    List<Drink> getTopThreeDrinks();
    List<Cat> getCategories();
    List<Drink> getDrinksForCategory(Cat category);

    int getBillsToday();

    int getSumMoney();
}
