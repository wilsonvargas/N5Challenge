import React from 'react';
import {BrowserRouter, Routes, Route, Navigate} from 'react-router-dom';

import HomePage from './Pages/HomePage.js';
import CreatePage from './Pages/CreatePage.js';
import MainLayout from './Layouts/MainLayout.js';
import EditPage from './Pages/EditPage.js';

function AppRouter() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="create" element={<CreatePage />} />
          <Route exact path="edit" element={<EditPage />} />

          <Route path="*" element={<Navigate replace to="/" />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default AppRouter;
