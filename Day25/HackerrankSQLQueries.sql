-- 1. https://www.hackerrank.com/challenges/weather-observation-station-5/problem?isFullScreen=true
select top 1 city, len(city) from station order by len(city), city;
select top 1 city, len(city) from station order by len(city) desc, city;

-- 2. https://www.hackerrank.com/challenges/harry-potter-and-wands/problem?isFullScreen=true
select id, age, coins_needed, power from 
(
    select w.id, p.age, w.coins_needed, w.power,
    Rank() over (partition by p.age, w.power order by w.coins_needed) rank
    from wands w join wands_property p on w.code = p.code where p.is_evil = 0
)
tmp 
where tmp.rank = 1
order by power desc, age desc;