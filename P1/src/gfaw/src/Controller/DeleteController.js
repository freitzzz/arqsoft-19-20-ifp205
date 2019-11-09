import { API_URL } from '../GorgeousFoodAPI_URL';

export async function deleteData(uri, deletedID) {
  let response = await fetch(API_URL + uri + '/' + deletedID, {
    method: 'DELETE'
  });

  if (response.ok) { // if HTTP-status is 200-299
    // get the response body (the method explained below)
    return response.status;
  } else {
    alert("HTTP-Error: " + response.status);
    return null;
  }
}