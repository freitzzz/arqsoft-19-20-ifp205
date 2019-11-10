import { API_URL } from '../GorgeousFoodAPI_URL';

export async function postData(uri, postData) {
  let response = await fetch(API_URL + uri, {
    method: 'POST',
    headers: new Headers({'content-type': 'application/json'}),
    body: postData
  });

  if (response.ok) { // if HTTP-status is 200-299
    // get the response body (the method explained below)
    return response.json();
  } else {
    alert("The data you have entered is invalid!" + "\nHTTP-Error: " + response.status);
    return null;
  }
}