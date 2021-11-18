let baseUrl='https://localhost:44364/api/';

export async function get(url, methodType,params ){
    return  fetch(baseUrl + url, {
            method: methodType,
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
            }
        });
}