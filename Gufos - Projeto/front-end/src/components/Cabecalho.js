import React, { Component } from "react";
import NavBar from '../components/NavBar';
import '../assets/css/cabecalho.css';

//withRouter para redirecionar as rotas
import {Link, withRouter} from 'react-router-dom';

import {usuarioAutenticado} from '../services/auth';

import logo from "../assets/img/icon-login.png";

class Cabecalho extends Component {

    logout(){
        localStorage.removeItem("usuario-gufos");
        this.props.history.push('/');
    }

  render() {
    // Header v1.0
    return (
      <header className="cabecalhoPrincipal">
        <div className="container">
          <img src={logo} alt="Gufos" />

          <nav className="cabecalhoPrincipal-nav">
            <div>
                <Link to="/">Home</Link>
            </div>

            <NavBar />
          </nav>
        </div>
      </header>
    );
  }
}

//componente utilizando withRouter para poder utilizar o redirect do logout
export default withRouter(Cabecalho);