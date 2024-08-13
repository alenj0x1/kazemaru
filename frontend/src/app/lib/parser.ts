export function projectBanner(banner: string | null, gradient: string | null) {
  let result = gradient ?? '';

  if (banner) {
    if (gradient) result += `, url("${banner}")`;
    else result += `url("${banner}")`;
    return result;
  }

  result += 'rgb(75, 75, 75);';
  return result;
}
