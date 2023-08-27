export const BASE_URL = "http://localhost:3001/api";

export default async function getAll() {
    const response = await fetch(`${BASE_URL}/projects`);
    return response.json();
}




