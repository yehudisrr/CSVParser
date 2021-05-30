import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Generate from './pages/Generate';
import Home from './pages/Home';
import Upload from './pages/Upload';

const App = () => {
    return (
            <Layout>
                <Route exact path='/generate' component={Generate} />
                <Route exact path='/' component={Home} />
                <Route exact path='/upload' component={Upload} />
            </Layout>
    );
}

export default App;