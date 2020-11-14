import axios from 'axios';

const api = axios.create(
    { baseURL:'http://3.87.226.24:5000/Carrinho' }
);

export const ListarCarrinho = async (cliente) => {
    const resp = await api.get('?idcliente=' + cliente);
    return resp.data;
}

export const Remover = async (id) => {
    const resp = await api.delete('/' + id);
    console.log(resp);
}

export const InserirCarrinhoApi = async (request) => {
    let response = await api.post('/cadastrar', request);
    return response;
}

export const alterarQuantidadeApi = async (idcarrinho, novaqtd) => {
    const response = api.put('/alterar/' + idcarrinho + "?newqtd=" + novaqtd);
    return response;
}