import React, { useEffect, useState } from "react";
import {
  fetchFoods,
  addToCart,
  fetchCart,
  fetchRecipes,
  removeFromCart,
} from "../services/foods";
import Food from "./Food";
import CartItem from "./CartItem";
import Recipe from "./Recipe";

function ShopSection() {
  const [foods, setFoods] = useState([]);
  const [cart, setCarts] = useState([]);
  const [recipe, setResipes] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      let recipes = await fetchRecipes();
      setResipes(recipes);
    };
    fetchData();
  }, []);

  useEffect(() => {
    const fetchData = async () => {
      let foods = await fetchFoods();
      setFoods(foods);
    };
    fetchData();
  }, []);

  useEffect(() => {
    const fetchData = async () => {
      let cart = await fetchCart();
      setCarts(cart);
    };
    fetchData();
  }, []);

  const onAddToCart = async (food) => {
    await addToCart(food);
    let cart = await fetchCart();
    let recipes = await fetchRecipes();
    setResipes(recipes);
    setCarts(cart);
  };

  const onRemoveFromCart = async (foodId) => {
    await removeFromCart(foodId);
    let cart = await fetchCart();
    let recipes = await fetchRecipes();
    console.log(cart);
    setCarts(cart);
    setResipes(recipes);
  };

  return (
    <section className="p-8 flex flex-row justify-start items-start gap-12">
      <div className="flex flex-col w-1/3 gap-10">
        <ul className="flex flex-col gap-5 flex-1">
          {foods.map((f) => (
            <li key={f.id}>
              <Food food={f} onSubmit={onAddToCart}></Food>
            </li>
          ))}
        </ul>
      </div>
      <div className="flex flex-col w-1/3 gap-10">
        <ul className="flex flex-col gap-5 flex-1">
          {cart.map((i) => {
            return (
              <li key={i.id}>
                <CartItem item={i} onRemove={onRemoveFromCart}></CartItem>
              </li>
            );
          })}
        </ul>
      </div>
      <div className="flex flex-col w-1/3 gap-10">
        <ul className="flex flex-col gap-5 flex-1">
          {recipe.map((r) => {
            return (
              <li key={Math.random()}>
                <Recipe recipe={r}></Recipe>
              </li>
            );
          })}
        </ul>
      </div>
    </section>
  );
}

export default ShopSection;
