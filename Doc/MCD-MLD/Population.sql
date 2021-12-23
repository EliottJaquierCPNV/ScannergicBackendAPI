INSERT INTO scannergic.ingredient (ingredient.name)
VALUE ("farine de blé"),("eau"),("levure"),("huile de colza"),("protéine de blé"),("vinaigre de table"),("sel de cuisine iodé"),("farine de malt d'orge");

INSERT INTO scannergic.allergen (allergen.name)
VALUE ("gluten"),("lactose"),("arachide");

INSERT INTO scannergic.product (product.name, product.UPC)
VALUE ("American Favorites", 7612345978900);

INSERT INTO scannergic.ingredient_has_allergen (ingredient_has_allergen.ingredient_id, ingredient_has_allergen.allergen_id)
VALUE (1, 1), (5, 1), (8, 1);

INSERT INTO scannergic.product_has_ingredient (product_has_ingredient.product_id, product_has_ingredient.ingredient_id)
VALUE (1, 1), (1, 2),(1, 3),(1, 4),(1, 5),(1, 6),(1, 7),(1, 8);


INSERT INTO scannergic.ingredient (ingredient.name)
VALUE ("semoule de maïs"),("arachide"),("huile de tournesol");

INSERT INTO scannergic.product (product.name, product.UPC)
VALUE ("Snack au maïs et aux arachides", 7612345678917);

INSERT INTO scannergic.ingredient_has_allergen (ingredient_has_allergen.ingredient_id, ingredient_has_allergen.allergen_id)
VALUE (10, 3);

INSERT INTO scannergic.product_has_ingredient (product_has_ingredient.product_id, product_has_ingredient.ingredient_id)
VALUE (2, 9), (2, 10),(2, 11),(2, 7);



INSERT INTO scannergic.ingredient (ingredient.name)
VALUE ("yogourt"),("sucre"),("extrait de café"),("arômes");

INSERT INTO scannergic.product (product.name, product.UPC)
VALUE ("Yogourt ferme Mocca", 7612345678924);

INSERT INTO scannergic.ingredient_has_allergen (ingredient_has_allergen.ingredient_id, ingredient_has_allergen.allergen_id)
VALUE (12, 2);

INSERT INTO scannergic.product_has_ingredient (product_has_ingredient.product_id, product_has_ingredient.ingredient_id)
VALUE (3, 12), (3, 13),(3, 14),(3, 15);