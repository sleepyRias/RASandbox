import { AxiosResponse } from "axios";
import { ArrayElement } from "../ArrayElement";
import * as HttpStatus from "http-status-codes";
export function mapResponse<T, M, R, RM>(
  response: AxiosResponse<JsonApiResponse<T, M, RM>>,
  mapper: (
    resource: JsonApiResource<T extends any[] ? ArrayElement<T> : T, M>
  ) => R
): T extends any[] ? R[] : R {
  if (response.status === HttpStatus.NO_CONTENT) {
    // @ts-ignore
    return;
  } else {
    const data = response.data.data;
    // @ts-ignore
    return Array.isArray(data) ? data.map(mapper) : mapper(data);
  }
}
