import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/shoes?sortBy=_createdOn%20desc');
}

export async function getById(id) {
    return get('/data/shoes/' + id);
}

export async function deleteById(id) {
    return del('/data/shoes/' + id);
}

export async function create(data) {

    return post('/data/shoes', data);
}

export async function edit(id, data) {
    return put('/data/shoes/' + id, data);
}

export async function getMyshoes(userId){

    return get(`/data/shoes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)
}

export async function getByBrand(query){
    return get(`/data/shoes?where=brand%20LIKE%20%22${query}%22`)
}