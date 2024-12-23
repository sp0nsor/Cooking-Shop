import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ShopSection from "./components/ShopSection";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<ShopSection></ShopSection>} />
      </Routes>
    </Router>
  );
}

export default App;
