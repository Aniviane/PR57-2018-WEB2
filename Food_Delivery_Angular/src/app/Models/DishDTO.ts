export class DishDTO {
    // public long Id { get; set;  }
    //     public string DishName { get; set; }

    //     public int Price { get; set; }

    //     public long RestaurantId { get; set; }
    id : number;
    dishName : string;
    price: number;
    restaurantId : number;
    constructor() {
        this.id = 0;
        this.dishName ="";
        this.price = 0;
        this.restaurantId = 0;
    }
}