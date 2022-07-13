export class DishDTO {
    // public long Id { get; set;  }
    //     public string DishName { get; set; }

    //     public int Price { get; set; }

    //     public long RestaurantId { get; set; }
    Id : number;
    DishName : string;
    price: number;
    RestaurantId : number;
    constructor() {
        this.Id = 0;
        this.DishName ="";
        this.price = 0;
        this.RestaurantId = 0;
    }
}