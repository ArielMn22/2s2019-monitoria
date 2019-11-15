import React, { Component } from "react";
import { parseJwt, usuarioAutenticado } from "../services/auth";

//Usado para redirecionar para uma rota
import { withRouter, Link } from "react-router-dom";

class NavBar extends Component {
  constructor() {
    super();
  }

  logout(event) {
    event.preventDefault();

    localStorage.removeItem("usuario-gufos");
    this.props.history.push("/");
  }

  render() {
    if (usuarioAutenticado() && parseJwt().permissao === "Administrador") {
      return (
        <div>
          <Link to="/tiposeventos">Tipos Eventos</Link>
          <Link to="/eventos/cadastrar">Eventos</Link>
          <span
            onClick={this.logout.bind(this)}
            style={{ cursor: "pointer" }}
            className="cabecalhoPrincipal-nav-login"
          >
            Sair
          </span>
        </div>
      );
    } else if (usuarioAutenticado() && parseJwt().permissao === "Aluno") {
      return (
        <div>
          <Link to="/eventos">Eventos</Link>
          <span
            onClick={this.logout.bind(this)}
            style={{ cursor: "pointer" }}
            className="cabecalhoPrincipal-nav-login"
          >
            Sair
          </span>
        </div>
      );
    } else {
      return (
        <div>
          <Link to="/login">Login</Link>
        </div>
      );
    }
  }
}

//Implemetar na exportação para que a rota do sair funcione
export default withRouter(NavBar);
