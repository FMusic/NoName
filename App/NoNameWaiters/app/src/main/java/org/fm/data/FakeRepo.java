package org.fm.data;

import org.fm.model.Cat;
import org.fm.model.Drink;

import java.util.ArrayList;
import java.util.List;

public class FakeRepo implements Repository {
    @Override
    public List<Drink> getTopThreeDrinks() {
        List<Drink> list = new ArrayList<>();
        Cat def = new Cat("Default");
        list.add(new Drink(10, "Kava s mlijekom", def));
        list.add(new Drink(10, "Cedevita", def));
        list.add(new Drink(10, "Sok od jagode", def));
        return list;
    }

    @Override
    public List<Cat> getCategories() {
        List<Cat> categories = new ArrayList<>();
        categories.add(new Cat("Topli napitci"));
        categories.add(new Cat("Hladni napitci"));
        categories.add(new Cat("Pive"));
        return categories;
    }

    @Override
    public List<Drink> getDrinksForCategory(Cat category) {
        List<Drink> list = new ArrayList<>();
        list.add(new Drink(10, "Piva s mlijekom", category));
        list.add(new Drink(10, "Cedevita", category));
        list.add(new Drink(10, "Sok od jagode", category));
        return list;
    }
}
