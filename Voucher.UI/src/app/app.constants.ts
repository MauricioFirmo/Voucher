import { HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

export const URL: any =
{
  API: environment.API_URL,
}

export const HTTP_OPTIONS = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Access-Control-Allow-Origin': '*',
    'Accept': 'applcation/ json',
  })
};
