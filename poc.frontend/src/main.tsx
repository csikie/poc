import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.tsx'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import '@/global.css'
import Counter from '@/pages/Counter.tsx';
import Login from '@/pages/Login.tsx';
import FetchData from './pages/FetchData.tsx';
import Users from './pages/Users.tsx';
import Roles from './pages/Roles.tsx';


const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "/counter",
        element: <Counter />,
      },
      {
        path: "/fetch-data",
        element: <FetchData />,
      },
      {
        path: "/users",
        element: <Users /> ,
      },
      {
        path: "/access-control",
        element: <h1>Access control</h1>,
      },
      {
        path: "/roles",
        element: <Roles />,
      },
    ],
  },
  {
    path: "/login",
    element: <Login />,
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>,
)
