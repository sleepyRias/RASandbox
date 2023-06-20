import { AxiosRequestConfig, AxiosInstance } from "axios";

export class AxiosRepository {
  constructor(protected axios: AxiosInstance) {}

  protected async sendGet<T>(url: string, config?: AxiosRequestConfig) {
    return await this.axios.get(url, config);
  }

  protected async sendHtmlGet(url: string, config?: AxiosRequestConfig) {
    return this.axios.get(url, config);
  }

  protected async sendDelete<T = void>(
    url: string,
    config?: AxiosRequestConfig
  ): Promise<T extends void ? void : T> {
    const response = await this.axios.delete(url, config);
    // @ts-ignore
    return response ? response : Promise.resolve();
  }

  protected async sendPost<T>(
    url: string,
    data?: any,
    config?: AxiosRequestConfig
  ) {
    return await this.axios.post(url, data, config);
  }

  protected async sendPut<T>(
    url: string,
    data?: any,
    config?: AxiosRequestConfig
  ) {
    return await this.axios.put(url, data, config);
  }

  protected async sendPatch<T>(
    url: string,
    data?: any,
    config?: AxiosRequestConfig
  ) {
    return await this.axios.patch(url, data, config);
  }
}
