package com.itheima.day15_collection_app.d10_genericity_interface;

public interface Data<E> {
    void add(E e);
    void delete(int id);
    void update(E e);
    E queryById(int id);
}
