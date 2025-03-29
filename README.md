# InputSystemLikeManager

**InputSystemLikeManager** は、Unity の新しい Input System を、旧 Input Manager のように扱える軽量なラッパーライブラリです。  
特に、「ボタンを離した瞬間（Input.GetButtonUp 相当）」が扱いにくいという課題を解決します。

## 特徴

- `Input.GetButton`, `Input.GetButtonDown`, `Input.GetButtonUp` のような感覚で利用可能
- `InputValue` をそのまま処理できるシンプルな設計
- 軽量・拡張性のある構造で、任意のアクションを追加しやすい
- 入力軸（axisMove, axisLook）にも対応

## インストール方法

1. PackageManagerからInputSystemをインポートしてください
2. `InputProxy.cs` を Unity プロジェクト内に追加してください。
3. Unity の新しい Input System を使用する設定にしてください（Edit > Project Settings > Player > Active Input Handling を `Input System Package` に変更）。

## 使用方法

### InputAction 側の設定

1. 空のGameObjectをInputProxyという名前で作成
2. InputProxyをアタッチ
3. Player Input をアタッチ
4. InputActionsを作成　（Projectで右クリック→Create→InputActions）
5. 作成したInputActionsを、PlayerInputにアタッチ
6. PlayerInputのBehaviorをBroadcast Messagesに![image](https://github.com/user-attachments/assets/5f71ca3f-2233-408b-abb3-63d9c255650e)
7. 作成したInputActionsの中身を編集（スティック）![image](https://github.com/user-attachments/assets/37f15d1e-7b7a-4830-b8db-018ce8da93c1)![image](https://github.com/user-attachments/assets/cccc8fda-b7dd-4775-8f9e-f924bd07e83c)
8. 作成したInputActionsの中身を編集（ボタン）![image](https://github.com/user-attachments/assets/d76dd8b5-5424-46ca-b5c4-52c988ec60ed)![image](https://github.com/user-attachments/assets/ae84d574-2f53-4879-9919-93225dffb939)

### 注意点
1. ボタンのAction Type は Pass Throughにしてください
2. ボタンのControl Type は Buttonにしてください

### 入力の取得例

以下のように使います。inputSystemはインスペクタから登録してください。

```csharp
 [SerializeField]
InputProxyInputSystem inputSystem;
```

```csharp
if (inputSystem.GetInput("Jump").down)
    rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
if (inputSystem.GetInput("Jump").up)
    rb.AddForce(Vector3.up * -10, ForceMode.Impulse);
```
