import axios from "axios";

export const fetchFoods = async () => {
  let response = await axios.get("http://localhost:5198/api/foods");

  return response.data;
};

export const addToCart = async (food) => {
  let response = await axios.post(
    "http://localhost:5198/api/foods/cart",
    food,
    {
      withCredentials: true,
    }
  );

  return response.status;
};

export const removeFromCart = async (foodId) => {
  let response = await axios.post(
    "http://localhost:5198/api/foods/cart/",
    { foodId },
    {
      withCredentials: true,
    }
  );

  return response.status;
};

export const fetchCart = async () => {
  let response = await axios.get("http://localhost:5198/api/foods/cart", {
    withCredentials: true,
  });

  return response.data;
};

export const fetchRecipes = async () => {
  let response = await axios.get("http://localhost:5198/api/foods/recipes", {
    withCredentials: true,
  });

  return response.data;
};
