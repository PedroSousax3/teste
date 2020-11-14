import axios from 'axios'

const api = axios.create (
    { baseURL : 'http://3.87.226.24:5000/Livro' }
);

export const ConsultarPorIdLivro = async (idlivro) => {
    const response = await api.get(`/${idlivro}`);
    return response;
}

export const ListarLivrosApi = async (posicao) => {
    const response = await api.get('/listar/' + posicao);
    return response;
}