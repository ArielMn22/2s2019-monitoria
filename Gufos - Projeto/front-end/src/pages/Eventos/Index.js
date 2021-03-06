import React, { Component } from "react";
import Cabecalho from "../../components/Cabecalho";
import Rodape from "../../components/Rodape/Rodape";
import Titulo from "../../components/Titulo";
import api from "../../services/api";
import '../../assets/css/flexbox.css'

class Index extends Component {
  constructor() {
    super();

    this.state = {
      listaEventos: []
    };
  }

  componentDidMount() {
    api.get("/eventos")
      .then(data => {
        this.setState({ listaEventos: data.data });
      });
  }

  render() {
    return (
      <div>
        <Cabecalho />

        <main class="conteudoPrincipal">
          <div class="container">
            <Titulo mensagem="Lista de Eventos" />

            <nav>
              <ul class="conteudoPrincipal-dados" id="ul-dados">
                {this.state.listaEventos.map((element) => {
                  return (
                    <li key={element.id} class="conteudoPrincipal-dados-link">
                      <h2 class="conteudoPrincipal-dados-titulo titulo-azul">
                        {element.titulo}
                      </h2>
                      <span class="conteudoPrincipal-icone-span">
                        {element.descricao}
                      </span>
                      <p className="titulo-tipo-evento"><small>{element.categoria.titulo}</small></p>
                    </li>
                  );
                })}
              </ul>
            </nav>
          </div>
        </main>

        <Rodape />
      </div>
    );
  }
}

export default Index;
