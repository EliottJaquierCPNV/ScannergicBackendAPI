INSERT INTO scannergic.allergen
VALUE (1, "gluten"),(2, "lactose"),(3, "arachide");

-- product with 2 allergens (farine de blé (id 1) = gluten (id 1), lait (id 2)= lactose (id 2))
INSERT INTO scannergic.ingredient
VALUE (1, "farine de blé"),(2,"lait"),(3,"levure"),(4,"huile de colza"),(5,"vinaigre de table"),(6,"sel de cuisine iodé");

INSERT INTO scannergic.product
VALUE (1,"American Favorites", 7612345978900);

INSERT INTO scannergic.ingredient_has_allergen
VALUE (1, 1), (2, 2);

INSERT INTO scannergic.product_has_ingredient
VALUE (1, 1), (1, 2),(1, 3),(1, 4),(1, 5),(1, 6);

-- Product with 1 allergen (arachide (id 8 ) = arachide (id 3))

INSERT INTO scannergic.ingredient
VALUE (7,"semoule de maïs"),(8,"arachide"),(9,"huile de tournesol");

INSERT INTO scannergic.product
VALUE (2,"Snack au maïs et aux arachides", 7612345678917);

INSERT INTO scannergic.ingredient_has_allergen
VALUE (8, 3);

INSERT INTO scannergic.product_has_ingredient
VALUE (2, 7),(2, 8),(2, 9);


-- Product without allergens

INSERT INTO scannergic.ingredient
VALUE (10,"yogourt"),(11,"sucre"),(12,"extrait de café"),(13,"arômes");

INSERT INTO scannergic.product
VALUE (3,"Yogourt ferme Mocca", 7612345978932);

INSERT INTO scannergic.product_has_ingredient
VALUE (3, 10), (3, 11),(3, 12),(3, 13);