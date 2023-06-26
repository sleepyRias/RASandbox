import { AxiosResponse } from "axios";
import { ArrayElement } from "../ArrayElement";
import { JsonApiResponse } from "./JsonApiResponse";

export function mapResponseSimple<T, R>(
  response: AxiosResponse<JsonApiResponse<T>>,
  mapper: (value: T extends any[] ? ArrayElement<T> : T) => R
) {
  return mapResponse(response, (resource) => mapper(resource.attributes));
}
