export class Product {
  constructor(
    public id: string,
    public name: string,
    public price: number,
    public tonnage: number,
    public region: number,
    public description?: string,
    public imageUrl?: string,
  ) {}
}
