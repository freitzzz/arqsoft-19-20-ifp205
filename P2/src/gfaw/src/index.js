import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Dashboard from './View/Dashboard';
import * as serviceWorker from './View/serviceWorker';

ReactDOM.render(<Dashboard />, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
