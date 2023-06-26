import { ArrayElement } from "../ArrayElement";
import { JsonApiResource } from "./JsonApiResource";
export interface JsonApiResponse<T, M = undefined, RM = undefined> {
  data: T extends any[]
    ? JsonApiResource<ArrayElement<T>, M>[]
    : JsonApiResource<T, M>;
  meta: RM;
}
