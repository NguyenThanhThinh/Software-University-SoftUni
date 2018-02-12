function gradToDegrees(grads) {
    grads %= 400;
    grads = grads < 0 ? 400 + grads : grads;
    grads *= 0.9;

    console.log(grads);
}