import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/cars?sortBy=_createdOn%20desc');
}

export async function getById(id) {
    return get('/data/cars/' + id);
}

export async function deleteById(id) {
    return del('/data/cars/' + id);
}

export async function create(data) {

    return post('/data/cars', data);
}

export async function edit(id, data) {
    return put('/data/cars/' + id, data);
}

export async function getMyCars(userId){

    return get(`/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)
}

export async function getByYear(query){
    return get(`/data/cars?where=year%3D${query}`)
}