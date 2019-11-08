import { API_URL } from '../GorgeousFoodAPI_URL';

export async function getIngredients() {
  let response = await fetch(API_URL + 'ingredients');

  if (response.ok) { // if HTTP-status is 200-299
    // get the response body (the method explained below)
    let json = response.json();

    return json;
  } else {
    alert("HTTP-Error: " + response.status);
    return null;
  }
}