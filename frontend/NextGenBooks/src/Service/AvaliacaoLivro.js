import axios from 'axios'

const api = axios.create(
    { baseURL : "http://3.87.226.24:5000/AvaliacaoLivro" }
);

export const listarAvaliacaoLivroApi = async (idlivro) => {
    const response = await api.get('/' + idlivro);
    console.log(response);
    return response;
}