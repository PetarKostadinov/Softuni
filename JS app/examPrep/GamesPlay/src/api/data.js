import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/games?sortBy=_createdOn%20desc');
}

export async function getById(id) {
    return get('/data/games/' + id);
}

export async function deleteById(id) {
    return del('/data/games/' + id);
}

export async function create(data) {

    return post('/data/games', data);
}

export async function edit(id, data) {
    return put('/data/games/' + id, data);
}

export async function getLatestGames() {
    return get(`/data/games?sortBy=_createdOn%20desc&distinct=category`);
}

export async function getAllComents (gameId){
    return get(`/data/comments?where=gameId%3D%22${gameId}%22`)
}

export async function postComent(data){
    return post('/data/comments', data)
}
