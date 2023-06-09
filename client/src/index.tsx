import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import {Provider} from "react-redux";
import {store} from "./store";
import {ApolloProvider} from "@apollo/client";
import {todoClient} from "./apollo";


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <React.StrictMode>
      <ApolloProvider client={todoClient}>
      <Provider store={store}>
          <App />
      </Provider>
      </ApolloProvider>
  </React.StrictMode>
);


