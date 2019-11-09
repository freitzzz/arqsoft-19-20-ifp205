import { API_URL } from '../GorgeousFoodAPI_URL';

export async function getData(uri) {
  let response = await fetch(API_URL + uri);

  if (response.ok) { // if HTTP-status is 200-299
    // get the response body (the method explained below)
    let json = response.json();

    return json;
  } else {
    console.log("HTTP-Error: " + response.status);
    return null;
  }
}