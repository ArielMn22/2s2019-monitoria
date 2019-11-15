import React, { Component } from "react";
import Header from "../../components/Cabecalho";

import "../../assets/css/flexbox.css";
import "../../assets/css/reset.css";
import "../../assets/css/style.css";

import Titulo from "../../components/Titulo";
import Rodape from "../../components/Rodape/Rodape";
import api from "../../services/api";

class TiposEventos extends Component {
  constructor() {
    super();
    this.state = {
      lista: [],
      nome: "",
      tituloPagina: "Lista Tipos Eventos"
    };

    this.atualizaEstadoNome = this.atualizaEstadoNome.bind(this);
    this.cadastraTipoEvento = this.cadastraTipoEvento.bind(this);
  }

  buscarTiposEventos() {
    api.get("/categorias")
      .then(data => {
        this.setState({ lista: data.data });
      })
      .catch(erro => console.log(erro));
  }

  componentDidMount() {
    this.buscarTiposEventos();
  }

  atualizaEstadoNome(event) {
    this.setState({ nome: event.target.value });
  }

  cadastraTipoEvento(event) {
    event.preventDefault();

    api.post("/categorias", {titulo : this.state.nome})
    .then(() => this.buscarTiposEventos())
    .catch(erro => console.log(erro));
  }

  render() {
    return (
      <div>
        <Header />

        <main className="conteudoPrincipal">
          <section className="conteudoPrincipal-cadastro">
            {/* <h1 className="conteudoPrincipal-cadastro-titulo">
              Tipos de Eventos
            </h1> */}
            <Titulo titulo={this.state.tituloPagina} />
            <div className="container" id="conteudoPrincipal-lista">
              <table id="tabela-lista">
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Título</th>
                  </tr>
                </thead>

                <tbody>
                  {this.state.lista.map(function(tipoevento) {
                    return (
                      <tr key={tipoevento.categoriaId}>
                        <td>{tipoevento.categoriaId}</td>
                        <td>{tipoevento.titulo}</td>
                      </tr>
                    );
                  })}
                </tbody>
              </table>
            </div>

            <div className="container" id="conteudoPrincipal-cadastro">
              {/* <h1 className="conteudoPrincipal-cadastro-titulo">
                Cadastrar Tipo de Evento
              </h1> */}
              <Titulo titulo="Cadastro Tipos de Eventos" />
              <form onSubmit={this.cadastraTipoEvento}>
                <div className="container">
                  <input
                    type="text"
                    value={this.state.nome}
                    onChange={this.atualizaEstadoNome}
                    id="nome-tipo-evento"
                    placeholder="tipo do evento"
                  />
                  <button className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro">
                    Cadastrar
                  </button>
                </div>
              </form>
            </div>
          </section>
        </main>

        {/* <footer className="rodapePrincipal">
          <section className="rodapePrincipal-patrocinadores">
            <div className="container">
              <p>Escola SENAI de Informática - 2019</p>
            </div>
          </section>
        </footer> */}

        <Rodape />
      </div>
    );
  }
}

export default TiposEventos;
