import axios from 'axios';
const api = axios.create(
    { baseURL:"https://viacep.com.br/" }
);


export const buscarEndereco = async (cep) => {
    const resp = await api.get(`ws/${cep}/json`);
    return resp.data;
}