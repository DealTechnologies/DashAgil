export interface InRequest<T> {
    success: boolean;
    message: string;
    data: T;
}
