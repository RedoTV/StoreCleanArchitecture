export default class Product{
  id?: number = 0
  name?: string = ''
  description?: string = ''
  category?: string = ''
  cost?: number = 0

  constructor(id?: number, name?: string, description?: string, category?: string, cost?: number){
    this.id = id;
    this.name= name;
    this.description = description;
    this.category = category;
    this.cost = cost;
  }
}
