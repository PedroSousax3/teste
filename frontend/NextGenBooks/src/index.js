import React from 'react';
import ReactDOM from 'react-dom';

import Rotas from './router.js'

const rootElement = document.getElementById("root");
ReactDOM.render(
  <React.StrictMode>
    <Rotas />
  </React.StrictMode>,
  rootElement
);



