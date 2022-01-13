INSERT INTO scannergic.ingredient
VALUE (NULL,"farine de blé"),(NULL,"eau"),(NULL,"levure"),(NULL,"huile de colza"),(NULL,"protéine de blé"),(NULL,"vinaigre de table"),(NULL,"sel de cuisine iodé"),(NULL,"farine de malt d'orge");

INSERT INTO scannergic.allergen
VALUE (NULL,"gluten"),(NULL,"lactose"),(NULL,"arachide");

INSERT INTO scannergic.product
VALUE (NULL,"American Favorites", 7612345978900);

INSERT INTO scannergic.ingredient_has_allergen
VALUE (1, 1), (5, 1), (8, 1);

INSERT INTO scannergic.product_has_ingredient
VALUE (1, 1), (1, 2),(1, 3),(1, 4),(1, 5),(1, 6),(1, 7),(1, 8);


INSERT INTO scannergic.ingredient
VALUE (NULL,"semoule de maïs"),(NULL,"arachide"),(NULL,"huile de tournesol");

INSERT INTO scannergic.product
VALUE (NULL,"Snack au maïs et aux arachides", 7612345678917);

INSERT INTO scannergic.ingredient_has_allergen
VALUE (10, 3);

INSERT INTO scannergic.product_has_ingredient
VALUE (2, 9),(2, 10),(2, 11),(2, 7);



INSERT INTO scannergic.ingredient
VALUE (NULL,"yogourt"),(NULL,"sucre"),(NULL,"extrait de café"),(NULL,"arômes");

INSERT INTO scannergic.product
VALUE (NULL,"Yogourt ferme Mocca", 7612345678924);

INSERT INTO scannergic.ingredient_has_allergen
VALUE (12, 2);

INSERT INTO scannergic.product_has_ingredient
VALUE (3, 12), (3, 13),(3, 14),(3, 15);