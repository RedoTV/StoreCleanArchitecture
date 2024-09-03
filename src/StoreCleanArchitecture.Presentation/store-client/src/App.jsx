import { RouterProvider } from "react-router-dom";
import "./App.css";
import { router } from "./routes";
// import { useState } from "react";

export default function App() {

  return (
    <>
      <RouterProvider router={router} />;
    </>
  );
}