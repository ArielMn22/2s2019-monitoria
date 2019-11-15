export const usuarioAutenticado = () => localStorage.getItem("usuario-gufos") !== null;

export const parseJwt = () =>{
    let jwtDecode = require("jwt-decode"); // Importando o jwt-decode

    var token = localStorage.getItem("usuario-gufos");

    return jwtDecode(token);
    // var base64Url = localStorage.getItem("usuario-gufos").split('.')[1];
    // var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    
    // return JSON.parse(window.atob(base64));
}