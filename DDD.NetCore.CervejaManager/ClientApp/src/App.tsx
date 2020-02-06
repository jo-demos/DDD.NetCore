import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Cervejas from './components/cerveja/lista';
import Revendedores from './components/revendedor/lista';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
        <Route path='/cerveja/lista' component={Cervejas} />
        <Route path='/revendedor/lista' component={Revendedores} />
    </Layout>
);
