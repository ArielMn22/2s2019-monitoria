export const usuarioAutenticado = () => localStorage.getItem("usuario-gufos") !== null;

export const parseJwt = () =>{
    let jwtDecode = require("jwt-decode"); // Importando o jwt-decode

    var token = localStorage.getItem("usuario-gufos");

    return jwtDecode(token);
}