import React from 'react';
import ReactDOM from 'react-dom';
import './index.scss';
import App from './App';
import { BrowserRouter, Route } from "react-router-dom";
import reportWebVitals from './reportWebVitals';
import 'antd/dist/antd.css';
import "semantic-ui-css/semantic.min.css";
import 'react-base-table/styles.css'
import "rsuite/dist/styles/rsuite-default.min.css";

import { Provider } from "react-redux";
import { createStore } from "redux";
import reducers from "./reducers";



let store=createStore(reducers);
window.store= store;
require('dotenv').config()
ReactDOM.render(
  <Provider store={store}>

<BrowserRouter>
    <Route component={App} />
  </BrowserRouter>
</Provider>,

  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
